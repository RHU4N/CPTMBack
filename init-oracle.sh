#!/bin/bash
# Executado pelo gvenzl/oracle-xe na primeira inicializacao do volume (uma unica vez).
# Cria o schema CPTM com a mesma senha de ORACLE_PASSWORD, mantendo
# consistencia com o healthcheck e a connection string da API.
set -e

sqlplus -s / as sysdba << SQL
ALTER SESSION SET CONTAINER = XEPDB1;

DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM DBA_USERS WHERE USERNAME = 'CPTM';
  IF v_count = 0 THEN
    EXECUTE IMMEDIATE 'CREATE USER CPTM IDENTIFIED BY "${ORACLE_PASSWORD}" DEFAULT TABLESPACE USERS TEMPORARY TABLESPACE TEMP';
    EXECUTE IMMEDIATE 'GRANT CONNECT, RESOURCE, UNLIMITED TABLESPACE TO CPTM';
    EXECUTE IMMEDIATE 'GRANT CREATE TABLE, CREATE VIEW, CREATE SEQUENCE, CREATE PROCEDURE, CREATE TRIGGER TO CPTM';
    DBMS_OUTPUT.PUT_LINE('Schema CPTM criado com sucesso.');
  ELSE
    DBMS_OUTPUT.PUT_LINE('Schema CPTM ja existe - pulando criacao.');
  END IF;
END;
/
EXIT;
SQL
