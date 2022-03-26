
docker stop mobile-api
docker rm  mobile-api:latest





echo "----------------Docker Build-----------------------" 
docker build -t mobile-api .
echo "----------------Docker Deploy-----------------------" 
docker run -p 8063:80 -t mobile-api --name mobile_api 

