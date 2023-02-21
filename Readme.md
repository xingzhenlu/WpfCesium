主要的步骤

1、创建wpf项目，通过nuget安装WebView2组件
``` csproj文件
<PackageReference Include="Microsoft.Web.WebView2" Version="1.0.1587.40" />
```

2、全局安装libman工具，创建js客户端库配置文件，下载 [Cesium](https:learn.microsoft.com/zh-cn/aspnet/core/client-side/libman/libman-cli?view=aspnetcore-6.0)库


``` .NET CLI
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
``` 
``` 其他指令
libman init
libman install 
libman restore 
``` 

3、创建index.html文件，位置“./lib/index.html”<br>
头部添加cesium样式（注意相对位置）
```
<link href="cesium/Widgets/widgets.min.css" rel="stylesheet">
```
尾部添加cesium的js库（注意相对位置）
```
<script src="cesium/Cesium.min.js"></script>
```
设定Cesium初始目录：
window.CESIUM_BASE_URL = './cesium/';<br>
设定CesiumToken<br>
隐藏右上角的帮助按钮：
navigationHelpButton: false <br>
隐藏logo版权：
viewer._cesiumWidget._creditContainer.style.display = "none";<br>
 其他写法按照[官方文档](https:www.cesium.com/learn/cesiumjs-learn/cesiumjs-quickstart)
<br>

4、在wpf中使用WebView2
在项目中设置lib文件夹属性为内容、始终复制<br>
在xaml中引入命名空间、使用控件，起个名字
```xaml
 xmlns:WebView="clr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf"
 <WebView:WebView2 x:Name="WebView" />
```
后台添加Loaded事件
设置禁用跨域错误CORS
等待CoreWebView2加载
定位本地文件
