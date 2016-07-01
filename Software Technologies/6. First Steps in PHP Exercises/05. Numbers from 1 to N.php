<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<!--Write your PHP Script here-->
<?php
if(isset($_GET['num'])) {
    $end = intval($_GET['num']);
    for($i = 1; $i <= $end; $i++) {
        echo $i . " ";
    }
}
?>
</body>
</html>