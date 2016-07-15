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

$query = "SELECT * FROM posts";
$result = $mysqli->query($query);

if(!$result) {
    die('Error! Failed to process query');
}

if($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
        echo "Id: " . $row['post_id'] . "<br>"
            . "Title: " . $row['title'] . "<br>"
            . "Content: " . $row['content'] . "<br>"
            . "Date: " . $row['date'] . "<br>";
    }
} else {
    echo "0 results";
}