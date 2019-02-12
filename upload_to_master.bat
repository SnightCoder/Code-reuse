@echo off

echo "Updating..."
git add .

git commit -m "Upload"

git push

echo "Update Complete"