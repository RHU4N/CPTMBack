-- Executado pelo gvenzl/oracle-xe na primeira inicialização do volume.
-- Roda como sysdba no CDB, precisa de ALTER SESSION para entrar no PDB.

ALTER SESSION SET CONTAINER = XEPDB1;

-- Bloco idempotente: cria o schema CPTM somente se ainda não existir.
DECLARE
  v_count NUMBER;
BEGIN
  SELECT COUNT(*) INTO v_count FROM DBA_USERS WHERE USERNAME = 'CPTM';
  IF v_count = 0 THEN
    EXECUTE IMMEDIATE 'CREATE USER CPTM IDENTIFIED BY root DEFAULT TABLESPACE USERS TEMPORARY TABLESPACE TEMP';
    EXECUTE IMMEDIATE 'GRANT CONNECT, RESOURCE, UNLIMITED TABLESPACE TO CPTM';
    EXECUTE IMMEDIATE 'GRANT CREATE TABLE, CREATE VIEW, CREATE SEQUENCE, CREATE PROCEDURE, CREATE TRIGGER TO CPTM';
    DBMS_OUTPUT.PUT_LINE('Schema CPTM criado com sucesso.');
  ELSE
    DBMS_OUTPUT.PUT_LINE('Schema CPTM ja existe — pulando criacao.');
  END IF;
END;
/
