# 0、日常办公

email：https://mail.mediinfo.com.cn/

oa: https://cmp.mediinfo.cn/

gitlab: https://git1.mediinfo.cn/hrp/applications/web

鸿鹄研发中台--白泽交付中台： https://mcrp.mediinfo.cn/#/

Cyan文档中心： https://doc.mediinfo.cn/



# 1、命名规范

## a.通用规范

① 项目及命名空间：一级公司HRP.二级产品RenLiZY.三级领域RenYuanGL



② 文件夹名：Dtos、Controllers、RemoteDtos、IRemoteServices、IServices、Models



③ 中文拼音类的命名规范：

​			小于等于三个汉字，则全拼，首字母大写；

​			大于三个汉字，则前面两个全拼，首字母大写，后面则首字母大写，且动词+名词的方式；



④ 删除统一的操作继承DeleteDto



⑤ Rso结尾是RemoteServices中用到的交互类



## b.文件夹划分		

### 	 API项目

​			  Controllers:  接口类

​			  Dtos:   页面交互类，业务名+Dto、业务类+ListDto、业务名+QueryDto、业务名+CreateDto,业务名+UpdateDto等

​			  IRemoteServices:  调用其他领域的类

​			  RemoteDtos:  放IRemoteService里用到的Rso,拷贝被调用的实体类

​              Services: 业务处理类

​			  IServices: 业务处理接口类

###     ORM项目

​			 Models: 实体类

​            Repositories: 仓储类

​			IRepositories: 仓储接口类

​	

## c.API项目规范

### 		Controllers的规范

​						① 命名空间： 项目名.Controllers

​						② 主Controller放在外层Controller目录中；该Controller的分部类放在同一个文件夹中，且分部类的文件名不带controller字样；

​						③  主Controller名称格式：二级领域名+[模块名]+Controller；遵循：命名规范

​						④ 所有接口上面加一个返回类型的特性，例如：[ProducessResponseType(typeof(List<ZhiGongXXDto>),StatusCodes.Status200OK)]

### 		Dtos的规范

​						① 命名空间： 项目名.Dtos

​						② Dto内的文件夹名不带领域前缀

​						③ Dto的文件名带上领域前缀

​						④ 查询类Dto继承BaseQuerDto,其他Dto都继承BaseDto

### 		IRemoteServices的规范

​						① 命名空间：项目名.IRemoteServices

​						② 每个RemoteDtos都在各自的领域文件夹中

​                        ③ RemoteDto 类名带上领域前缀，拷贝被调用的接口返回类，以Rso结尾，不是Dto

### 		IServices的规范

​						① 命名空间：项目名.IServices

​						②对应Service的类

### 		ORM项目

#### 					Models的规范

​								① 命名空间: 项目名.Models

​								②Model类里面的属性的规范，按照命名规范；每个Model上面加上[Table("表名")] 的特性

​								③Model类名格式： 一级前缀 + 二级前缀 + 业务名（按命名规范，且是驼峰）+ Model, 例如表名为HR_RYGL_ZHIGONGXXLS，那么Model类名应为HR_RYGL_ZHIGONGXXLSModel

#### 					Repositories的规范

​								命名空间： 项目名.Repositories	

#### 				  IRepositories的规范

​								①命名空间：项目名.IRepositories

​								②IRepositories类名格式： 对应Repository实现类



## d.临时变量的规范

​	  ① 临时变量以语义化为主

​	  ② 简单对象可以使用英文

​	  ③ 无强制要求必须使用中文或者英文

​	  ④ 首字母小写，使用驼峰命名 



# 2、开发调试

① visual studio2019 + vscode

② git版本控制工具：使用命令行（ **git命令复制操作：选中当前的命令，再点击鼠标右键**）

③ vue前端(以hrp为例)：

​		hrp-web

④ 微服务后端：（以人员管理为例--每个模块是一个微服务）

​		renyuangl

⑤ 调试步骤：

​    第一步：

​	将hrp-web中的 config目录下的proxy.js对应的target 修改为本地服务地址：

```js
 '/hrp-renlizy-renyuangl': {
  	target:'http://localhost:20000',

  	changeOrigin: true,

  	pathRewrite: {

   	'^/hrp-renlizy-renyuangl': '/hrp-renlizy-renyuangl'

 	 }

 },
```

​    第二步：

​		启动对应的本地后台微服务程序

   第三步（前端站点启动）：

​	   package.json中的scripts/serve  启动

​	  terminal 中切换到  cd hrp-web目录下

​	 执行命令：

​	         npm run serve   即可启动前端的站点    

​	 根据控制台的输出地址 即可访问对应的站点进行后续调试

​     注：

​	     src/service 对应的是前端的服务  基本上和后端controller有一对一的效果



# 3、开发时注意事项

① 一般涉及到取多个表单的值时，采用多个Task进行查询数据，能用异步方法就用异步方法

例如：(接口)

​		api/v1/ZhiGongDA/GetZhiGongDAByID

示例代码：

```C#
var tasks = new List<Task>();

//教育经历
tasks.Add(_jiaoYuJLRepository.GetList(id).ContinueWith(async dto =>{
    zhigongdadto.JiaoYuJLs = (await dto).MapTo<JiaoYuJL, JiaoYuJLDto>().ToList();
}));
//工作经历
tasks.Add(_gongZuoJLRepository.GetList(id).ContinueWith(async dto =>{
    zhigongdadto.GongZuoJLs = (await dto).MapTo<GongZuoJL, GongZuoJLDto>().ToList();
}));

//所有的Task都执行完成之后进行下一步操作
await Task.WhenAll(tasks.ToArray());
```

# 4、框架

项目依赖关系

![image-20210806112104046](C:\Users\licha\AppData\Roaming\Typora\typora-user-images\image-20210806112104046.png)

(以HRP.RenLiZY.RenYuanGL为例)

## ① HRP.RenLiZY.RenYuanGL.Host 

```c#
 public class Startup : IMCRPStartup
    {
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            base.Configure(app, env, configuration);
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
             //注入了仓储
            services.AddCustomIntegrations();

            //注入SampleDbContext
            services.AddCustomDbContext<SampleDbContext>(opt =>
            {
                 	                        opt.UseEfCoreOracle(configuration.GetConnectionString("default"));
            });

            base.ConfigureServices(services, configuration);
        }
    }
```



## ② HRP.RenLiZY.RenYuanGL.API

Controllers: webApi Controller的文件夹

Services: 内部服务

RemoteServices： 远程服务

​				远程用到的Dto，建议使用Rso作为结尾

Dtos: 接口用到的Dto

Specifications：查询的规则

​		Filters

​	    Fuse

​		Fuse用于Api熔断,添加了Fuse的Api将会在超过设定值时熔断，此特性仅可以应用于Action上

​	    使用

```c#
 [HttpGet("fuse"),Fuse]
 public IActionResult FuseTest()
```

​	    说明

​        Fuse 有2个参数，`tolerance`表示`secondsDelay`时间间隔内最大异常次数，默认为2，`secondsDelay`表示异常最大间隔，默认60秒。也就是当一个Action在60秒内出现2次异常则不可用，当超过60秒后会自动恢复正常.

> Fuse仅捕获`当前实例`的异常，也就是说`不`会叠加多个相同实例的异常次数



## ③ HRP.RenLiZY.RenYuanGL.ORM

​	

EntityTypeConfigurations: 实体映射的配置



Models: 数据库映射的对象



IRepositories: 仓储接口



Repositories: 仓储实现





3栋9楼会议室



