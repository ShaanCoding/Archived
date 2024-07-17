#!/bin/bash

ARCHIVE_REPO="git@github.com:ShaanCoding/Archived.git"
ARCHIVE_DIR="Archived"
GITHUB_USER="ShaanCoding"
REPOS=("YOUR_REPOSITORY_NAME") # Can be array, no commas needed
BRANCH_NAME="main"  # Specify the branch name here

# Clone the archive repository if not already cloned
if [ ! -d "$ARCHIVE_DIR" ]; then
  git clone $ARCHIVE_REPO
fi

cd $ARCHIVE_DIR

# Loop through each repository
for REPO in "${REPOS[@]}"
do
  REMOTE_URL="https://github.com/$GITHUB_USER/$REPO.git"
  
  # Add remote and fetch the specified branch
  git remote add $REPO $REMOTE_URL
  git fetch $REPO $BRANCH_NAME
  
  # Check if prefix already exists
  if git rev-parse --verify --quiet main:$REPO; then
    echo "Prefix $REPO already exists. Skipping subtree add."
  else
    # Merge the repository into a subdirectory
    git subtree add --prefix=$REPO $REPO/$BRANCH_NAME
  fi

  # Remove the remote
  git remote remove $REPO
done

# Push changes to the archive repository
git push origin main