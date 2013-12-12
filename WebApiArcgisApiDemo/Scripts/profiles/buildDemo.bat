SET BASE_DIR=C:\Demo\WebApiArcgisApiDemo\WebApiArcgisApiDemo\Scripts

cd "%BASE_DIR%\src\util\buildscripts"

rd /s /q "%BASE_DIR%\release"

java -Xms256m -Xmx256m  -cp ../shrinksafe/js.jar;../closureCompiler/compiler.jar;../shrinksafe/shrinksafe.jar org.mozilla.javascript.tools.shell.Main  ../../dojo/dojo.js baseUrl=../../dojo load=build --require ../../app/run.js --profile ../../../profiles/app.profile.js  --releaseDir ../release

copy "%BASE_DIR%\src\index.html" "%BASE_DIR%\release"

cd "%BASE_DIR%\profiles"