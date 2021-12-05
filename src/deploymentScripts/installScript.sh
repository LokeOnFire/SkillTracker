
sudo service docker start
cd /home/ec2-user/SkillTrackerService/src/
docker-compose -f ./docker-compose.yml -f docker-compose.override.yml down
docker rm $(docker ps -aq) -f
docker rmi $(docker images -q) -f
docker-compose -f ./docker-compose.yml -f docker-compose.override.yml up -d
