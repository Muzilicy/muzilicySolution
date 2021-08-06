学习项目
git入门指令--同步远程仓库和分支操作
	https://www.cnblogs.com/code-duck/p/13228508.html

git常使用的命令
1、git init —在当前目录新建一个代码库。
2、 git config user.name=””git config user.email=””—设置代码提交时候的信息。
3、 git clone 需要clone 远程地址 ––从服务器端克隆项目到本地
4、 git status —查看文件修改状态。
5、 git diff 文件路径 ––查看该文件与上次提交修改代码的差别。
6、 git diff –-cached 文件路径 ––查看本地缓冲和上次提交的差别。
7、 git checkout –b 分支名称 ––新建一个临时分支。
8、 git checkout 分支名称 ––切换分支。
9、 git branch —查看所有的分支。
10、 git branch –D temp —强制删除一个分支
11、 git pull —将服务端代码更新到本地。
12、 git add 文件路径 —提交文件到暂冲区。
13、 git add –A —提交所有的需要add 的文件到缓冲区。
14、 git commit –m ‘提交说明’—将缓冲区的文件提交到本地库中。提交说明尽量将提交内容简单明了的表达清楚。
15、 git push origin master —将已经提交到本地的仓库的代码push到远程服务器。
16、 git log —显示提交的日志。
17、 git show [commit 的Id] — 显示某次提交的元数据和内容变化。
18、 git show [commit Id] –-stat —-显示提交的文件名称
19、 git checkout —恢复暂存区的所有文件。
20、 git reset [file/commit ID] – 重置暂存区的指定文件。用来撤销git commit
21、 git reset –hard [commit 的Id] —将本地版本退回到提交之前的版本。这个操作会将自己新写的代码全部撤销没了。
22、 git cherry-pick temp —-合并临时分支到当前分支。
23、 git commit –amend —修改最近一次提交说明的内容同时可以合并提交。对已经Push 的无效。
24、git rm <删除的本地仓库中文件路径（前提已经提交到远程仓库）> git commit -m “delete file” 分两步执行，可以删除远程仓库对应的文件

提交步骤
首先你先通过git init git clone 基本环境准备好后，你写完自己的代码想要提交到远程服务器。
git status 查看改动的文件有哪些
分别git diff 改动文件路径 看看有没有空格之类。检查格式，改动具体代码
确认无误后 git add 需要提交的文件路径 也可以加入改动的都是需要提交可以git add .
git pull
git commit -m “提交备注” 切记commit 之前 先git pull
git push origin master

提交完成
————————————————
版权声明：本文为CSDN博主「蜗牛乌龟一起走」的原创文章，遵循CC 4.0 BY-SA版权协议，转载请附上原文出处链接及本声明。
原文链接：https://blog.csdn.net/qq_29897369/article/details/81430380