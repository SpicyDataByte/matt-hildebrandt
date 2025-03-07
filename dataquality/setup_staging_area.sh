echo "Creating the database"

createdb -h localhost -U postgres -p 5432 billingDW

echo "Downloading the data files"
wget https://blahblahblah.cloudstorage/billing-datawarehouse.tgz

echo "Extracting files"
tar -xvzf billing-datawarehouse.tgz

echo "Creating schema"

psql  -h localhost -U postgres -p 5432 billingDW < star-schema.sql

echo "Loading data"

psql  -h localhost -U postgres -p 5432 billingDW < DimCustomer.sql

psql  -h localhost -U postgres -p 5432 billingDW < DimMonth.sql

psql  -h localhost -U postgres -p 5432 billingDW < FactBilling.sql

echo "Finished loading data"

echo "Verifying data"

psql  -h localhost -U postgres -p 5432 billingDW < verify.sql

echo "Successfully setup the staging area"
