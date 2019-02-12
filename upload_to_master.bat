@echo off

color A
echo [Uploading...]
color 9
git add .

git commit -m "Upload"

git push

color A
echo [Upload Complete]