Create trigger SatisAzalt
On SalesMovements 
After insert
as
Declare @ProductId int 
Declare @Piece int
Select @ProductId = ProductId , @Piece= Piece from inserted
update Products set UnitInStok = UnitInStok - @Piece where ProductId = @ProductId 