<?php

require_once('config.php');
require_once('functions.php');
session_start();
$requestParsed = parseRequest();
processRequest($requestParsed);
