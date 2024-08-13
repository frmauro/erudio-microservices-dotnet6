# erudio-microservices-dotnet6

## command to create container docker mysql
docker run --name=mysql1 -d -v geek-shopping-product-api-mysql-data:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=123 -e MYSQL_DATABASE=geek_shopping_product_api -p 3306:3306 mysql:5.7


## commands to make migrations in visual studio
  add-migration AddProductDataTableOnDB
  Remove-Migration AddProductDataTableOnDB
  
## commands to make migrations via dotnet ef
dotnet ef migrations add AddProductDataTableOnDB
dotnet ef migrations remove AddProductDataTableOnDB
  
  
