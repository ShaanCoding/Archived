# Ghost example

This example deploys self-hosted version of [Ghost](https://ghost.org/). Internally it uses a MySQL database to store the data.

[![Deploy on Railway](https://railway.app/button.svg)](https://railway.app/new/template/ghost)

## ✨ Features

- Ghost
- MySQL

## 💁‍♀️ How to use

- Click the Railway button 👆
- Add the environment variables

### S3

If you do not add the S3 environment variable, your images/files will not be persisted between deploys.

```
AWS_ACCESS_KEY_ID
AWS_SECRET_ACCESS_KEY
AWS_DEFAULT_REGION
GHOST_STORAGE_ADAPTER_S3_PATH_BUCKET
GHOST_STORAGE_ADAPTER_S3_ASSET_HOST  // optional
GHOST_STORAGE_ADAPTER_S3_PATH_PREFIX // optional
GHOST_STORAGE_ADAPTER_S3_ENDPOINT // optional
GHOST_STORAGE_ADAPTER_S3_SSE // optional
GHOST_STORAGE_ADAPTER_S3_FORCE_PATH_STYLE // optional
GHOST_STORAGE_ADAPTER_S3_ACL // optional
```

- Add the `MAILGUN_SMTP_LOGIN` and `MAILGUN_SMTP_PASSWORD` variables if you want to invite users to your admin panel or send emails to your subscribers when you publish a new post.

## 📝 Notes

- Railway's filesystem is ephemeral which is why any changes to the filesystem are not persisted between deploys. This is why, this example uses Cloudinary for storage.
- The above limitation also affects the way themes work with Ghost, we use the `bin/themes.sh` script to copy over the themes every time you deploy. That way, the theme is always present.
  - To add a theme, first add the package as a dependency to the `package.json` file and then add it to the list of themes in the `bin/themes.sh` file.
  - Do NOT add a theme directly using the Ghost UI, it will look like it worked but will break whenever you deploy your app again.
