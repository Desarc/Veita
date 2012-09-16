<html>
	<head>
		<title>Middag i Veita</title>
	<head>

	<body>
		<h1>Velkommen til middag/fellesoversikt for Veita!</h1>
		<?php
			if(isset($_POST['submit'])) {
				echo "<br />Middag lagt til!<br />";
			}
		?>
		<h3>Legg til ny middag/felles:</h3>
		<form method="post" action="<?php echo $_SERVER['PHP_SELF']; ?>">
		Beskrivelse av måltidet:
		<input type="text" name="beskr" size="50" maxlength="100" /><br />
		Pris:
		<input type="text" name="pris" size="5" maxlength="20" /><br />
		<?php
			$host = "mysql.stud.ntnu.no";
			$user = "oyvinric_veita";
			$pass = "pellePoliti";
			$dbname = "oyvinric_middag";
			$con = mysql_connect($host,$user,$pass);
			if (!$con) {
				die('Could not connect: '.mysql_error());
			}
			
			mysql_select_db($dbname, $con);
			
			$result = mysql_query("SELECT * FROM beboere");
			$beboere = array();
			while($row = mysql_fetch_array($result)) {
					if(strcmp($row['navn'], "Oyvin") == 0) {
						array_push($beboere, "Øyvin");
					}
					else {
						array_push($beboere, $row['navn']);
					}
			}
			
			if(isset($_POST['submit'])) {
				$sql = "INSERT INTO middag VALUES (NULL, '$_POST[beskr]', '$_POST[pris]', CURRENT_DATE, '$_POST[sponsor]')";
				if (!mysql_query($sql, $con)) {
					die('Error: '.mysql_error());
				}
				$result = mysql_query("SELECT id FROM middag WHERE beskrivelse='$_POST[beskr]' AND dato=CURRENT_DATE AND pris='$_POST[pris]' AND sponsor='$_POST[sponsor]'");
				$middagid;
				while($row = mysql_fetch_array($result)) {
					$middagid = $row['id'];
				}
				$del = $_POST['deltakere'];
				for($i = 0; $i < count($del); $i++) {
					if($del[$i] == $_POST['sponsor']) {
						continue;
					}
					$sql = "INSERT INTO deltakere VALUES ('".$del[$i]."', '".$middagid."' )";
					if (!mysql_query($sql, $con)) {
						die('Error: '.mysql_error());
					}
				}				
			}
			
			if(isset($_POST['delete'])) {
				$sql = "DELETE FROM middag WHERE id='$_GET[del]'";
				if (!mysql_query($sql, $con)) {
					die('Error: '.mysql_error());
				}
			}
			
			echo "Betalt av:";
			for($i = 0; $i < count($beboere); $i++) {
				echo '<input type="radio" name="sponsor" value="'.($i).'" />'.$beboere[$i];
			}
			echo "<br /><br />Måltidets deltakere:";
			for($i = 0; $i < count($beboere); $i++) {
				echo '<input type="checkbox" name="deltakere[]" value="'.($i).'">'.$beboere[$i];
			}
			echo "<br /><br />";
		?>

		<input type="submit" name="submit" value="Legg til!" />
		</form>
		
		<h3>Oversikt:</h3>
			<table border="1" cellpadding="10">
				<tr>
					<td><b>Dato</b></td>
					<td><b>Beskrivelse</b></td>
		<?php
			for($i = 0; $i < count($beboere); $i++) {
				echo "<td>".$beboere[$i]."</td>";
			}
		?>
				<td></td>
				</tr>

		<?php
			$result = mysql_query("SELECT * FROM middag");
			while($row = mysql_fetch_array($result)) {
					echo "<tr>";
					$date = getdate(strtotime($row['dato']));
					echo "<td>".$date['mday'].".".$date['mon']."</td>";
					echo "<td>".$row['beskrivelse']."</td>";
					for($j = 0; $j < count($beboere); $j++) {
						if($j == $row['sponsor']) {
							echo "<td>O</td>";
						}
						else {
							$result2 = mysql_query("SELECT * FROM deltakere WHERE middag_id='".$row['id']."' AND beboer_id='".$j."'");
							if (is_resource($result2) && mysql_num_rows($result2) > 0) {
								echo "<td>X</td>";
							}
							else {
								echo "<td></td>";
							}
						}
					}
					echo '<td><form method="post" action="'.$_SERVER['PHP_SELF'].'?del='.$row['id'].'"><input type="submit" name="delete" value="Delete" /></form></td>';
					echo "</tr>";
			}
		
			mysql_close($con);	
		?>
			</table>
	</body>
</html>