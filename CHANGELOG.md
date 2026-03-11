## 0.7.0
**Features**
- Added the configuration file name as an argument
- Merged the project and solution configuration files
- Separated archive naming from project names
- Added ability to add arbitrary substitutions

## 0.6.0
**Other**
- Upgraded to .NET 10

## 0.5.3
**Other**
- Moved to GitHub

## 0.5.1
**:sparkles: Features**
- Added `Test` task

## 0.5.0
**:hammer: Refactors**
- Cleanup pass

**:green_heart: CI/CD**
- Added `pull: true` to all steps

**:arrow_up: Dependencies**
- Upgraded to `Cake.Frosting@5.1.0`

## 0.4.0
**:boom: Breaking Changes**
- Renamed `--oproject` to `--general-project`
- Renamed `--oprofile` to `--general-profile`
- Renamed `--oversion` to `--general-version`
- Renamed `--oskip-substitution` to `--general-skipSubstitution`

**:sparkles: Features**
- Added `defaultProject` to solution-level config, making `--general-project` optional
  - [!] One of these does need to be defined
- Added default value of `12.34.56` to `--general-version`, making it optional

**:bug: Bug Fixes**
- Fixed `Substitute` step not using the correct method of skipping execution if `--general-skipSubstitution` was defined

**:recycle: Refactors**
- Wrapped internal configuration in an `InternalConfig` class

## 0.3.0
**:boom: Breaking Changes**
- Removed `Version` parameter from `SolutionConfig`
- Added mandatory `--oversion` argument (because the default CLI highjacks `--version`)
- Prefixed all existing arguments with `o` for consistency (i.e. `--oproject`, `--oprofile`, etc.)

## 0.2.6
**:bug: Bug Fixes**
- Fix project references

## 0.2.5
**:bug: Bug Fixes**
- Re-add runtime exclusion to `JetBrains.Annotations`

## 0.2.4
**:recycle: Refactors**
- Marked `JetBrains.Annotations` dependency as private

## 0.2.3
**:recycle: Refactors**
- Upgraded `Common.Build.Generator`'s language version to 13

## 0.2.2
**:bug: Bug Fixes**
- Fix incorrectly package source generator

## 0.2.1
**:sparkles: Features**
- Add ability to skip `Substitution` step to facilitate easier local debugging

## 0.2.0
**:sparkles: Features**
- Add `Common.Build.Generator` source generation for easier integration

## 0.1.1
**:question: Other**
- Minor refactoring

## 0.1.0
**:question: Other**
- Initial release
