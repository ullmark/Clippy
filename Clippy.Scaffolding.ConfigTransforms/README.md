Clippy Scaffolding
==================
Clippy Scaffolding is meant to make it faster to get a project up and running by automatically setting upp various
"nice to have" stuff.

Config Transforms
------------------
This package will do the folling;
  - Renames Web.config (or App.config) to Web.Base.config (or App.Base.config).
  - Creates Two new Build Configurations and adds transforms for each:
    - Web.Production.config
	- Web.Test.config
  - Configures transformation on build.