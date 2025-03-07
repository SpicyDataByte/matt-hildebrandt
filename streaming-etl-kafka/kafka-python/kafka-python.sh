wget https://archive.apache.org/dist/kafka/3.5.1/kafka_2.12-3.5.1.tgz

tar -xzf kafka_2.12-3.5.1.tgz

# New Terminal
cd kafka_2.12-3.5.1
bin/zookeeper-server-start.sh config/zookeeper.properties

# New Terminal
cd kafka_2.12-3.5.1
bin/kafka-server-start.sh config/server.properties

# New Terminal
cd kafka_2.12-3.5.1
pip3 install kafka-python
touch admin.py
touch producer.py
touch consumer.py

python3 admin.py
python3 producer.py

# New Terminal
cd kafka_2.12-3.5.1
python3 consumer.py