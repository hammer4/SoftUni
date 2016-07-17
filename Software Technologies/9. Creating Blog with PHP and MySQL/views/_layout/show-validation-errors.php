<script>
    <?php
        foreach (array_reverse($this->validationErrors) as $fieldName => $errorMsg) {
            $fieldJson = json_encode($fieldName);
            $errorMsgJson = json_encode($errorMsg);
            echo "showValidationError($fieldJson, $errorMsgJson);\n";
        }
    ?>
</script>
