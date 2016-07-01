<?php
for($i=0; $i<255; $i+=51) {
    for($j=$i; $j<$i+50; $j += 5) {
        echo "<div style=\"background-color: rgb($j, $j, $j);\"></div>";
    }
    echo "<br>";
}
?>
