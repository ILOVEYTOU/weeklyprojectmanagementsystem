CREATE PROC SendEmal
@Id int,
@AgentEmail varchar(250),
@ClientEmail varchar(250)

AS

	INSERT INTO Emailsend(AgentEmail,ClientEmail) 
	 VALUES (@AgentEmail,@ClientEmail)