# Casper

The  dark mode enabled version of default theme for [Ghost](http://github.com/tryghost/ghost/). If you're just looking to download the original version, head over to the [releases](https://github.com/TryGhost/Casper/releases) page.

&nbsp;

![Home](https://user-images.githubusercontent.com/278469/55558098-f697a900-5708-11e9-8e80-2abcc9da2977.jpg)
![Author](https://user-images.githubusercontent.com/278469/55558126-057e5b80-5709-11e9-840c-4ccb8fdcd5d0.jpg)
![Page](https://user-images.githubusercontent.com/278469/55558127-0616f200-5709-11e9-89aa-ad9cd3b7fdb2.jpg)
![Post](https://user-images.githubusercontent.com/278469/55558128-0616f200-5709-11e9-9db6-9930228854d0.jpg)
![Tag](https://user-images.githubusercontent.com/278469/55558130-0616f200-5709-11e9-9c38-78a72995401c.jpg)

&nbsp;

# What do you have to do?

To enable the dark mode on your Ghost site, download the latest release of this theme and copy and paste the following code into `Code injection -> Site Footer` in Ghost Admin panel.

```html
<script>
    document.onkeyup = function(e) {
        if (e.altKey && e.which == 78) {
            localStorage.setItem('mode', (localStorage.getItem('mode') || 'dark') === 'dark' ? 'light' : 'dark');
            localStorage.getItem('mode') === 'dark' ? document.querySelector('body').classList.add('dark') : document.querySelector('body').classList.remove('dark');
        }
    };
</script>
```

The default shortcut key combination is set to `ALT + N` and you can set your preferred key by replacing `78` in above code.
* To get the prefered key code: https://keycode.info/


# Copyright & License

Copyright (c) 2013-2019 Ghost Foundation - Released under the [MIT license](LICENSE).
