<!DOCTYPE html>
<html>
<head>
    <title>Numbers 1 to 20</title>
</head>
<body>
<ul>
    <?php
    for($i = 1; $i<=20; $i++) {
        if($i % 2 == 1) {
            $color = 'blue';
        } else {
            $color = 'green';
        }
        echo "\t<li><span style='color: $color'>$i</span></li>\n";
    }
    ?>
</ul>
</body>
</html>