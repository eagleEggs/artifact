<?php

$run=escapeshellcmd('jupyter nbconvert --execute plotBook.ipynb');
$result=shell_exec($run);
echo $result;

?>
