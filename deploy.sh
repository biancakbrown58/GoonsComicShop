docker build -t sdg-goonscomicshop-image . 

docker tag sdg-goonscomicshop-image registry.heroku.com/goonscomicshop/web

docker push registry.heroku.com/goonscomicshop/web

heroku container:release web -a goonscomicshop