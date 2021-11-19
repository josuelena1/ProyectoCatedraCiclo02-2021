![https://docs.microsoft.com/en-us/dotnet/csharp/](https://img.shields.io/badge/Lenguaje-C%23-brightgreen.svg)
![https://www.microsoft.com/es-es/sql-server/](https://img.shields.io/badge/Proveedor%20Base%20de%20Datos-SQL%20Server-red.svg)
<br/>
<a href="https://creativecommons.org/licenses/by-sa/3.0/es/">
<img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_SYja6RT8hf-xUKIaJYnX9q68dRcyBSuaK6DHyzgW1HUgwRv-Btr91bBi0aiP78rJQGQ&usqp=CAU"
     alt="Markdown Monster icon" width="120" height="42.3"/></a>


## Desarrolladores:warning::
Antes de abrir la aplicacion deberan seguir los pasos enlistados [aqui](#devsReq).

<br/>

# Clinica Dental
 Proyecto para **Programacion Orientada a Objetos** (POO) y **Modelamiento de Bases de Datos** (MDB).
<br />

### Integrantes
- **CD210488** Jairo Rafael Colocho Díaz
- **AE210567** Bryan Josué Alberto Elena
- **CV210468** Oscar Rolando Cañas Valdizón
- **HM210444** Javier Enrique Hernández Márquez
- **PR210566** Mercedes Guadalupe Pérez Rivas
- **VC200416** Francisco Armando Ventura Cortez

## Tabla de contenido

### Seccion Principal
- [Acerca del proyecto](#about)
  - [Metodo de Instalacion (requiere Visual Studio)](#install)

### Seccion desarrolladores :computer:
- [Requisitos para desarolladores](#devsReq)
  - [Requisitos Iniciales](#initReq)
  - [Requisitos Adicionales](#aditReq)
  - [Paquetes Nuget](#nuget)
- [Sql Server](#sqlServer)
  - [Acceder a SQL Server por medio de tu computadora usando IP](#sqlTcpRef)

<br/>

<a name="about"></a>
# Acerca del proyecto

<img src="README Resources\SplashScreen.png" Width="341.5"/>

<br/>
Esta aplicacion fue desarrollada para las clinicas dentales. Esta aplicacion permite administrar pacientes, citas, tratamientos, alergias de pacientes y usuarios del sistema con sus respectivos roles y posiciones laborales. Ademas, esta aplicacion permite controlar los metodos de conexion a la base de datos de SQL Server.

<a name = "install"></a>
## Metodo de instalacion (requiere Visual Studio)

Para instalar esta aplicacion se requiere que se sigan los siguientes pasos y ademas se cumplan los requisitos solicitados (Vease [Requisitos iniciales](#initReq) y tambien vease [Requisitos adicionales](#aditReq)).

1. **Verifique si se han cumplido los requisitos señalados [aqui](#devsReq).**
2. [Descargue](https://github.com/Oscar-02/ProyectoPOO_MDB/archive/refs/heads/master.zip)  o clone este repositorio con <br/>
` git clone https://github.com/Oscar-02/ProyectoPOO_MDB.git `
3. Abra Visual Studio sin ningun proyecto y/o solucion abierto.
    1. Desde la barra de menus (arriba de la ventana de Visual Studio), dirijase a **Extensiones > Administrar extensiones**<br/> <img src = "README Resources\Install Images\extensions.png"/><br/>
    2. Desde la ventana "Administrar extensiones" busque `Windows App SDK` y presione **Descargar** (tambien puede descargarlo desde [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ProjectReunion.MicrosoftProjectReunionPreview)). <br/>
    **Nota:** Una vez descargado se le solicitara cerrar Visual Studio para instalarla.<img src="README Resources\Install Images\extensionName.png"><br/>
    3. Una vez cerrado Visual Studio, iniciara el asistente de instalacion de extensiones de Visual Studio (VSIX Installer) y cuando aparezca la pantalla con el nombre de la extension, presione en **Modify**. <br/>
    <img src="README Resources\Install Images\extInstall.png" Width="265.5"/><br/>
    4. Una vez finalizado, cierre el asistente y siga al paso 4.
4. Desde la carpeta raiz, dirijase a _Proyectos > Windows_ClinicaDental > Windows_ClinicaDental.sln_ y ejecutelo. Espere que finalice la carga.<br/>
**NOTA:** El tiempo que demora en abrir depende de muchos factores, entre ellos la edicion de Visual Studio. VS2019 es mas lento que VS2022 pero no afecta en el desarrollo de la aplicacion.
5. Vayase a la barra de menus y dirijase a _Herramientas > Administrador de paquetes NuGet > Consola del administrador de paquetes. Se arbrira una consola de PowerShell.<br/><img src="README Resources\NuGet Install\shortcut.png" Width="410"/><br/>
6. Instale **cada uno de los paquetes enlistados** en la seccion [Paquetes Nuget](#nuget). Un ejemplo de como debe instalarse:<br/><img src="README Resources\NuGet Install\install.png"><br/>
7. Si ya se ha finalizado la instalacion de TODOS los paquetes enlistados, puede ejecutar la aplicacion y listo. A partir de ese momento, puede abrir la aplicacion desde el menu Inicio sin ningun inconveniente.


<br/>


<a name="devsReq"></a>
# Requisitos para desarrolladores

<a name="initReq"></a>
## Requisitos iniciales

Como este proyecto esta desarrollado bajo `Windows UI Library 2` (UI preparado para Windows 11) necesita que, antes de abrir la solucion del proyecto `Windows_ClinicaDental` se instalen los siguientes requisitos:

| Requisito | Version Minima | Informacion adicional |
| - | :- | -: | 
| Visual Studio 2019 o superior | VS2019 16.11 <br/> VS2022 17.0 Preview 2 | https://visualstudio.microsoft.com/es/<br/>Tambien puedes revisar la version ya instalada desde Visual Studio Installer |
|Carga de trabajo de VS:<br/>`Desarrollo de escritorio de .NET` | | Instalable desde Visual Studio Installer (requiere Visual Studio)<br/>https://docs.microsoft.com/es-es/visualstudio/install/modify-visual-studio?view=vs-2019 |
|Carga de trabajo de VS:<br/>`Desarrollo de la plataforma universal de Windows` |  | Instalable desde Visual Studio Installer (requiere Visual Studio)<br/>https://docs.microsoft.com/es-es/visualstudio/install/modify-visual-studio?view=vs-2019 |
| Extension de VS:<br/>`Windows App SDK (Experimental)` | VS2019 16.11 <br/> VS2022 17.0 Preview 2 <br/> *Cargas de trabajo* antes mencionadas | https://marketplace.visualstudio.com/items?itemName=ProjectReunion.MicrosoftProjectReunionPreview <br/> Tambien instalable desde Visual Studio > Extensiones > Administrar extensiones |
| Paquetes NuGet (ver siguiente seccion) | VS2019 16.11 <br/> VS2022 17.0 Preview 2 <br/> *Cargas de trabajo* antes mencionadas | Ver seccion _"Paquetes NuGet"_ |

<a name="aditReq"></a>
## Requisitos Adicionales

Tambien necesarios, la aplicacion necesita de estos requisitos para que funcione totalmente y sin errores detectados.
| Requisito | Version Minima | Mas Informacion|
| :- | :-: | -: |
| Windows 10 - Windows 11 | Win10 v1809 comp. 17763 <br/> Win11 v21H1 comp. 22000 | Verifica si existen actualizaciones desde Windows Update |
| SQL Server <strong>\*\*</strong> | Ultima version disponible | Ultima version de **SQL Server _Developer_** <strong>\*\*</strong> |

**(\*\*)**: Solicitamos el uso de SQL Server _Developer_ debido a que la version _Express_ del mismo no es admite el servicio `Agente SQL Server`, servicio necesario para la ejecucion de esta aplicacion. Este servicio permite acceder por medio de la cadena de conexion al servidor en general.


<br/>

<a name="nuget"></a>
## Paquetes Nuget

A diferencia de `.NET Framework`, `.NET` no incluye ciertos paquetes / referencias (en ciertos casos) como `System.Data.Sqlclient`, elementos necesarios para que la solucion funcione al 100%. Estos elementos son llamados **Paquetes NuGet**. Ademas, aunque Visual Studio restaure estos paquetes en el momento de compilacion del proyecto, suele pasar que no se restauren completamente y muestre advertencias y/o errores de compilacion y la aplicacion no se habra depurado completamente. <br/> <br/>
Para evitar estos problemas, recomendamos instalarlos manualmente. Para instalarlos, deben:

1. Abrir Visual Studio con la solucion y proyecto `Windows_ClinicaDental` abiertos.
2. Ir a _Pestaña Herramientas > Administrador de paquetes NuGet > Consola de Administrador de Paquetes_. <br/> Se abrira una consola de Powershell.
3. Insertar un comando por paquete segun la siguiente tabla (ingresar todos):

| Paquete NuGet | Comando de Powershell |
| - | -: |
| Microsoft.UI.Xaml | `Install-Package Microsoft.UI.Xaml -Version 2.8.0-prerelease.210927001` |
| Microsoft.Data.SqlClient| `Install-Package Microsoft.Data.SqlClient -Version 4.0.0-preview3.21293.2` |
| Microsoft.Win32.Registry | `Install-Package Microsoft.Win32.Registry -Version 6.0.0-preview.5.21301.5` |
| Microsoft.SqlServer.ConnectionInfo | `Install-Package Microsoft.SqlServer.ConnectionInfo -Version 150.18097.0-xplat` |
| Microsoft.SqlServer.SqlManagementObjects | `Install-Package Microsoft.SqlServer.SqlManagementObjects -Version 161.46521.71` |
| System.Drawing.Common | `Install-Package System.Drawing.Common -Version 6.0.0-rc.2.21480.5` |
| Win2D.uwp | `Install-Package Win2D.uwp -Version 1.26.0` |

<br/>

<a name="sqlServer"></a>
# SQL Server

<a name="sqlTcpRef"></a>
## Acceder a SQL Server por medio de tu computadora usando IP

Aunque, de manera predeterminda, la aplicacion esta diseñada para conectarse de manera local directamente; puedes conectarte, tanto tu como otros dispositivos, a esta aplicacion y a su base de datos.
<br/><br/>
Si quieres usar tu PC como un servidor en tu red de area local (es decir, solamente conexion entre varios dispositivos de tu misma red) deberas habilitar ciertos elementos en tu router\* que permitiran el acceso a tu PC:

1. Establecer la conexion WiFi - Ethernet con una IP dinamica. Deberas establecerla desde tu router usando la _direccion MAC de tu PC_\*\*.
2. Si tu router\* tiene la habilidad de usar servidores virtuales, deberas crear un servidor virtual con la direccion IP dinamica de tu dispositivo.
3. Abrir los _puertos TCP_\*\*\* correspondientes de SQL Server en tu router\*. De manera predeterminada, el puerto es `1433` (tanto de entrada como de salida).

**(\*)**: Los pasos pueden depender de las marcas y modelos de router.<br/>
**(\*\*)**: Puedes obtener la direccion MAC por medio del `Simbolo del Sistema`, escribiendo el comando `ipconfig /all` y finalmente buscar el dispositivo a utilizar.<br/>
***(\*\*\*)***: Si abriste los puertos y aun no puedes conectarte, pueda que necesites tambien abrir los puertos TCP desde el `Firewall de Windows con Seguridad Avanzada`.