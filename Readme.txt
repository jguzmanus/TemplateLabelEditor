

cd project
$ git init
Git will reply

Initialized empty Git repository in .git/
You’ve now initialized the working directory—​you may notice a new directory created, named ".git".

Next, tell Git to take a snapshot of the contents of all files under the current directory (note the .), with git add:

$ git add .
This snapshot is now stored in a temporary staging area which Git calls the "index". You can permanently store the contents of the index in the repository with git commit:

git commit -m "test"
git remote add origin https://github.com/jguzmanus/various.git
git push -u origin master
