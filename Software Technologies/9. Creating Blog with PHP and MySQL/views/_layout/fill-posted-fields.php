<script>
<?php
    foreach ($_POST as $fieldName => $fieldValue) {
        $fieldJson = json_encode($fieldName);
        $valueJson = json_encode($fieldValue);
        echo "setFieldValue($fieldJson, $valueJson);\n";
    }
?>
</script>
