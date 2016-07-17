USE blog;

INSERT INTO users (username, password_hash, full_name) VALUES ('admin', '$2y$10$QlKthcuYhn.XP/gy5A/OZeQdOzIznqxqOf/qBrSAnGpoW4labIL0W', null);
INSERT INTO users (username, password_hash, full_name) VALUES ('nakov', '$2y$10$XViubT.zSoBtskZmKl6kdOX8Yq7T7tLrcrLn/5dkAqbgjVACeFUGe', 'Svetlin Nakov');
INSERT INTO users (username, password_hash, full_name) VALUES ('maria', '$2y$10$gzlpX/N5apTruTBajMJwM.0h9OgLVgQxk6N0YhGy2iY4BI73SYkKO', 'Maria Ivanova');
INSERT INTO users (username, password_hash, full_name) VALUES ('ani', '$2y$10$9T9bN6ctJ4R.fdnLvzsdQOj0sk4mWqwohILMx60/jP1YEXtJguhD2', 'Ani Kirova');
INSERT INTO users (username, password_hash, full_name) VALUES ('joe', '$2y$10$aIOC0qiNK1mjZdUUbuj/Teh49VI/g9xanuWCNYEUruwcvOGVaXOGK', 'Joe Green');
INSERT INTO users (username, password_hash, full_name) VALUES ('test', '$2y$10$I5y7X1ZilitEZYOztOI5SuA2rBeRJUj/ZhlgmSZK32LPqaqh3Gy3q', '');
INSERT INTO users (username, password_hash, full_name) VALUES ('it''s security "test"<br>', '$2y$10$thSx6ceSyCPxdl.BDGLhKe7lQu8d3oopQ/LJYK8ma.Dz6jWbOgj8C', 'it''s security "test"<br>');
INSERT INTO users (username, password_hash, full_name) VALUES ('vikash', '$2y$10$Exc5mMcThOlEnXZ2.kAPl.ouBSDl8S0GjD.3vvB6KohMpcgfsLsde', 'Vikash Jain');

INSERT INTO posts (title, content, date, user_id) VALUES ('Work Begins on HTML5.1', '<p>The World Wide Web Consortium (W3C) has begun work on <b>HTML5.1</b>, and this time it is handling the creation of the standard a little differently. The specification has its <b><a href="https://w3c.github.io/html/">own GitHub project</a></b> where anyone can see what is happening and propose changes.</p>

<p>The organization says the goal for the new specification is "to <b>match reality better</b>, to make the specification as clear as possible to readers, and of course to make it possible for all stakeholders to propose improvements, and understand what makes changes to HTML successful."</p>

<p>Creating HTML5 took years, but W3C hopes using GitHub will speed up the process this time around. It plans to release a candidate recommendation for HTML5.1 by <b>June</b> and a full recommendation in <b>September</b>.</p>
', '2016-05-22 10:13:37', 2);
INSERT INTO posts (title, content, date, user_id) VALUES ('Windows 10 Preview with Bash Support Now Available', '<p>Microsoft has released a new <b>Windows 10 Insider Preview</b> that includes native support for <b>Bash running on Ubuntu Linux</b>. The company first announced the new feature at last week''s Build development conference, and it was one of the biggest stories of the event. The current process for installing Bash is a little complication, but Microsoft has a blog post that explains how the process works.</p>

<p>The preview build also includes <b>Cortana</b> upgrades, extensions support, the new <b>Skype</b> Universal Windows Platform app and some interface improvements.</p>', '2016-05-20 11:18:26', 8);
INSERT INTO posts (title, content, date, user_id) VALUES ('Atom Text Editor GetsNew Windows Features', '<p>GitHub has released <b>Atom 1.7</b>, and the updated version of the text editor offers improvements for Windows developers. Specifically, it is now easier to build in Visual Studio, and it now supports the Appveyor CI continuous integration service for Windows.</p>

<p>Other new features include improved tab switching, tree view and crash recovery. GitHub noted, "Crashes are nobody''s idea of fun, but in case Atom does crash on you, it periodically saves your editor state. After relaunching Atom after a crash, you should find all your work saved and ready to go."</p>

<p>GitHub has also released a beta preview of Atom 1.8.</p>
', '2016-05-07 11:21:21', 3);
INSERT INTO posts (title, content, date, user_id) VALUES ('SoftUni 3.0 Launched', '<p>The <b>Software University (SoftUni)</b> launched a new training methodology and training program for software engineers in Sofia.</p>

<p>It is a big step ahead. Now SoftUni offers several professions:</p>
<ul>
  <li>PHP Developer</li>
  <li>JavaScript Developer</li>
  <li>C# Web Developer</li>
  <li>Java Web Developer</li>
</ul>
', '2016-04-07 11:25:40', 2);
INSERT INTO posts (title, content, date, user_id) VALUES ('Git 2.8 Adds Security and Productivity Features', '<p>Version 2.8 of the open-source distributed version-control system Git has been released. The new edition provides a variety of new features, bugfixes and other improvements.</p>

<p>According to GitHub, the most notable new features include:</p>

<ul>
<li><strong>Parallel fetches of submodules:</strong> “Using ‘git submodules,’ one Git repository can include other Git repositories as subdirectories. This can be a useful way to include libraries or other external dependencies into your main project. The top-level repository specifies which submodules it wants to include, and which version of each submodule,” wrote Jeff King, a Git team member, in a <a href="https://github.com/blog/2131-git-2-8-has-been-released">blog post</a>. According to him, if users have multiple submodules, fetches can be time-consuming. The latest release allows users to fetch from multiple submodules in parallel.</li>
<li><strong>Don’t guess my identity: </strong>Instead of using one e-mail address for all of a user’s open-source projects, they can now tell Git what user name and e-mail they want to use before they commit.</li>
<li><strong>Convergences with Git for Windows:</strong> The Git team has been working on making Git as easy to work with on Windows as it is on Linux and OS X. The latest release includes Git commands rewritten in C; Windows-specific changes from the Git for Windows project; and the ability to accept both LF and CRLF line endings. “This continuing effort will make it easier to keep the functionality of Git in sync across platforms as new features are added,” King wrote.</li>
<li><strong>Security fixes: </strong>Git 2.8 addresses the vulnerability CVE-2016-2324. There have not been any reported exploits, but the vulnerability could execute arbitrary code when cloning a malicious repository, according to King.</li>
</ul>

<p>Other features include the ability to turn off Git’s clean and smudge filters; the ability to see where a particular setting came from; the ability to easily diagnose end-of-line problems; the ability to see a remote repository’s default branch; and support for cloning via the rsync protocol has been dropped.</p>

<p>The full release notes are available <a href="https://github.com/git/git/blob/v2.8.0/Documentation/RelNotes/2.8.0.txt">here</a>.</p>
', '2016-01-17 11:27:50', 5);
INSERT INTO posts (title, content, date, user_id) VALUES ('Rogue Wave Updates Zend Framework', '<p>Rogue Wave is updating its open-source framework for developing Web applications and services. According to the company, this is the first major release in four years. Zend Framework 3 features support for PHP 7, middleware runtime and performance enhancements.</p>

<p>The newly released support for PHP 7 aims to simplify how developers create, debug, monitor and deploy modern Web and mobile apps in PHP 7. “This is an exciting time to be a PHP developer,” said Zeev Suraski, cofounder of Zend and CTO of Rogue Wave. “With Zend Framework 3, we’re continuing our quest to make creating PHP applications simpler, more accessible and faster.”</p>

<p>In addition, version 3 of the framework features an architectural structure that allows developers to use components within Zend Framework apps or any other framework in order to reduce dependencies, and to enable reuse within the PHP ecosystem.</p>

<p>Another key update to the solution is a new middleware runtime. Expressive is designed to focus on simplicity and interoperability, and it enables developers to customize their solutions.</p>

<p>“I’m extremely proud of the work we’ve done with Expressive,” said Matthew Weier O’Phinney, principal engineer and Zend Framework project lead at Rogue Wave. “Expressive signals the future of PHP applications, composed of layered, single-purpose PSR-7 middleware.”</p>
', '2015-11-22 11:57:40', 5);
