# fantastic-system


## Project Description

This project is an attempt to create a 3D RPG reminiscent of classic SNES and PS titles using Unity 3D.
At this time the project is in a genesis stage and is focused on creating a minimal engine for the game.
As such, no distinct setting or plot have been defined and gameplay mechanics are largely either undefined or subject to change. 


## Project Setup - Windows

### Unity

- Install or update Unity to version 5.3.4f1
- available from https://unity3d.com/get-unity/download/archive

### Git for Windows

- Download Git for Windows (v2.10.1)
- available from https://git-scm.com/download/win
- Install, choosing the following options:
  - **Checkout as-is, commit as-is**: we are currently uncertain of the effects of Unix-style line endings on a Unity project.
  - Other options as you choose - please **make a note** of your options in case troubleshooting is necessary later
- The following installation options were used when creating the repository:
  - Components: **all** checked **except** *Additional icons*; *On the desktop*; *Use a TrueType font in console*
  - PATH: **Use Git from Windows Command Prompt** (although I prefer using Git Bash as seen below)
  - Line endings: **Checkout as-is, commit as-is**
  - Terminal Emulator: **MinTTY**
  - Extra Options: **all**
  
### Clone Repository

- Start Git Bash. This is a minimal Bash shell packaged with Git for Windows. Some basic utilities familiar to a Linux user are available.
- Navigate to a desired location to create the project. Do not create a project folder; that will happen as part of the clone
- Enter the command: `git clone https://github.com/jonathan-wideman/fantastic-system.git` You may be prompted for GitHub login credentials.

This command will create a folder named `fantastic-system` which is the root folder for both the repository and the Unity Project.
At a later point it may be desirable to have the Unity project contained in a subfolder of the repository but that is currently unnecessary.
You may rename this folder as desired without any known ramifications.

### Configure Git

To support a uniform workflow, please make the following configuration changes:

**Change the default push behavior**

- Enter the command: `git config push.default current`

This command will cause changes that you push to GitHub to be placed in a branch with the same name as on your local working copy by default.
Pushing to discrete branches helps to ensure that the repository structure accurately represents the workflow of any changes, as well as the use of pull-requests to promote peer-review of changes.


## Git & GitHub Workflow

> **Note to git newbies**
>
> Don't worry if you don't understand all the terminology in this section.
> I'm trying to get this written down as is and I will work on a more beginner-friendly version later.
> In the meantime, I plan to clarify this process with team members in person.
> Here are simple main points to remember:
> - Do new work in a new branch (a branch is a separate copy of changes made to the repository with a given start point)
> - Commit work often (a commit is a way to save a record of changes made to a branch; it is a fixed point in the repository history)
> - Use pull requests to submit changes (a pull request is a way to organize applying changes made in a branch to another branch)
> - The branch `master` is sacred - don't touch it on GitHub without permission.
> - When in doubt, ask!
>
> These few rules will keep things somewhat organized; everything else is relatively easy to amend if necessary.
>
> Thanks for your cooperation!
>
> @jonathan-wideman

### Guidelines

To support a uniform workflow, please adhere to the following guidelines whenever possible:

- Ensure that all changes are made in a new branch.

- Limit branches to contain one discrete feature or fix as much as possible.

- Branch names should follow these conventions:
  - use kebab-case, eg. `this-name-is-inlowercase-and-separated-by-hyphens`
  - prefix branch names with your initials, eg. `jw-some-feature`
  - if multiple people are working on one branch, list initials of each, with the primary first, eg. `jw-zz-includes-work-by-ziggy-zaggerson`
  - if the branch is a bugfix, follow initials with the word fix, eg. `jw-fix-all-the-things`
  - use short descriptive branch names (unlike some of the above), eg. `jw-add-readme`

- Commit changes frequently, with descriptive messages.
Committing nonfunctional or incomplete work to a local branch is acceptable; it helps to back up work in progress.
Please indicate these WIP commits with the word `incremental` at the beginning of the commit message.

- When you have completed work on a branch, pull master to your local copy, merge master into your branch, and resolve any merge conflicts if possible.
You may then push your branch to GitHub and create a pull request.

- If you are unsure how to appropriately resolve any conflicts, identify the author of the conflicting changes using `git blame` and contact them to discuss resolution.
You may push your branch to GitHub to facilitate conflict resolution.
Please avoid incremental conflict resolution commits as they tend to make the intent unclear; it is better if they are all resolved as part of the merge commit.

- Avoid merging changes to master yourself, and/or without peer review.
Instead, create a pull request for changes and wait for another contributer to review and merge the branch.

_**(WIP - Additional info and explanation to come)**_

### Troubleshooting

- If Unity crashes while loading the project, try deleting the Library folder before reopening the project. This should not harm any content you have created since Unity uses the Library folder as a cache for compiled or processed versions of the content in the Assets folder and it will be rebuilt if it is missing when the project is opened.

- If MonoDevelop hangs when opening a file, try opening a known working file and from the Build menu, select Clean All, then Rebuild All before reopening the file.
