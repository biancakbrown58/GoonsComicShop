docker build -t sdg-goonscomicshop-imagev2 . 

docker tag sdg-goonscomicshop-imagev2 registry.heroku.com/goonscomicshop/web

docker push registry.heroku.com/goonscomicshop/web

heroku container:release web -a goonscomicshop