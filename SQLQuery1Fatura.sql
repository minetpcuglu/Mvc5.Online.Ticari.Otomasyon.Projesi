Create Trigger TutarEklee
On BillPens
After Insert
As
Declare @BillId int 
Declare @Amount decimal(18,2)
Select @BillId=BillId , @Amount=Amount from inserted
update Bills set Totel= Totel+ @Amount where BillId=@BillId
