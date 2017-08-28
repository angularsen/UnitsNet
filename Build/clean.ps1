$root = "$PSScriptRoot\.."
$artifactsDir = "$root\Artifacts"
if (test-path $artifactsDir) {
  write-host -foreground blue "Delete Artifacts dir"
  rm -r -fo $artifactsDir -ErrorAction Continue
}
write-host -foreground blue "Delete dirs: bin, obj"
ls $root -inc bin,obj -r -fo | ri -r -fo -ErrorAction SilentlyContinue