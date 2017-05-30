if (test-path .\Artifacts) {
  write-host -foreground blue "Delete Artifacts dir"
  rm -r -fo .\Artifacts -ErrorAction Continue
}
write-host -foreground blue "Delete dirs: bin, obj"
ls . -inc bin,obj -r -fo | ri -r -fo -ErrorAction SilentlyContinue