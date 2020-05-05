FROM microsoft/mssql-server-linux:2017-latest

# FROM mcr.microsoft.com/mssql/server:2017-latest

RUN mkdir -p /opt/mssql-scripts/
COPY /sql-data/* /opt/mssql-scripts/

ENV MSSQL_SA_PASSWORD=P@ssw0rd
ENV ACCEPT_EULA=Y

RUN ( /opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" \
 &&  opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'P@ssw0rd' -i /opt/mssql-scripts/000.CreateDb.sql \
 && pkill sqlservr
# && /opt/mssql-tools/bin/sqlcmd \
#     -S localhost \
#     -U SA -P 'P@ssw0rd' \
#     -Q 'RESTORE DATABASE FNMPBroker FROM DISK = "/opt/mssql-backups/Broker.bak" WITH MOVE "FNMSBroker" TO "/opt/mssql/data/FNMSBroker.mdf", MOVE "FNMSBroker_log" TO "/opt/mssql/data/FNMSBroker_log.ldf"' \
#  && pkill sqlservr
