<?php

require_once "vendor/autoload.php";

$queueURL = "URL HERE";

$client = new \Aws\Sqs\SqsClient([
    'profile' => 'default',
    'region' => 'us-east-2',
    'version' => '2012-11-05'
]);

try {
    
    $result = $client->receiveMessage([
        'QueueUrl' => $queueURL
    ]);

    echo "starting\n";

    if(!empty($result->get("Messages"))){
        echo $result->get("Messages")[0]['Body'].PHP_EOL;

        $client->deleteMessage([
            'QueueUrl' => $queueURL,
            'ReceiptHandle' => $result->get("Messages")[0]["ReceiptHandle"]
        ]);
    }else{
        echo "Sem mensagens";
    }

} catch (\Aws\Exception\AwsException $e) {
    throw $e;
}