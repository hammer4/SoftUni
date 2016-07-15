<?php
$hostname = 'localhost';
$username = 'root';
$password = '';
$dbname = 'blog';

$mysqli = new mysqli($hostname, $username, $password, $dbname);

if($mysqli->connect_errno) {
    die('Error! Failed to connect to MySQL');
}

$mysqli->set_charset('utf8');

$query = "SELECT * FROM users";
$result = $mysqli->query($query);

if(!$result) {
    die('Error! Failed to process query');
}

if($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
        echo "Id: " . htmlspecialchars($row['id']) . "<br>"
            . "Username: " . htmlspecialchars($row['username']) . "<br>"
            . "Full name: " . htmlspecialchars($row['fullname']) . "<br>";
    }
} else {
    echo "0 results";
}