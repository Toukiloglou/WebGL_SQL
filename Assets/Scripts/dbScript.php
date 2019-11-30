<?php	
	$servername = "localhost";
	$username = "id11783040_testuser";
	$password = "123456789";
	$dbname = "id11783040_testdb";	
	
	$sqlStatment = $_POST["sqlStatement"];
	
	if($sqlStatement != "") {
		$conn = new mysqli($servername, $username, $password, $dbname);

		if ($conn->connect_error) {
			die("Connection failed: " . $conn->connect_error);
		}

		$result = $conn->query($sqlStatement);
		
		if (!$result) {
			echo 'Could not run query: ' . mysql_error();
			exit;
		} else {
			$row = mysql_fetch_row($result);
			echo $row['id'];		
		}		
		
		$conn->close();
				
	} else {
		echo("SQL execution failed");
	}
?>