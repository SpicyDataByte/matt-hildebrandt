# Download Kafka
wget https://archive.apache.org/dist/kafka/2.8.0/kafka_2.12-2.8.0.tgz

# Extract Kafka
tar -xzf kafka_2.12-2.8.0.tgz

# start ZooKeeper
cd kafka_2.12-2.8.0
bin/zookeeper-server-start.sh config/zookeeper.properties

# start broker service
cd kafka_2.12-2.8.0
bin/kafka-server-start.sh config/server.properties

# create a topic
cd kafka_2.12-2.8.0
bin/kafka-topics.sh --create --topic news --bootstrap-server localhost:9092

# start Producer
bin/kafka-console-producer.sh --topic news --bootstrap-server localhost:9092
Good morning
Good day
Enjoy the Kafka lab

# start Consumer
cd kafka_2.12-2.8.0
bin/kafka-console-consumer.sh --topic news --from-beginning --bootstrap-server localhost:9092
