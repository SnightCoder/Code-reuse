@echo off

echo "Uploading..."
git add .

git commit -m "Upload"

git push

echo "Upload Complete"