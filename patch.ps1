$path = 'c:\Users\TEST RIG\.gemini\antigravity\scratch\WinSystemTools\src\Program.cs'
$content = Get-Content -Raw $path
$old = @"
                  // Virtualization Engine Launch
                  string qemuArgs = "-m " + memArg + " -smp " + cpuArg + " -cdrom \"" + isoPath.Text + "\" -boot d -vga qxl -net nic,model=virtio -net user -rtc base=localtime";
                  if (accel.Checked) qemuArgs += " -accel whpx -accel tcg";
"@
$new = @"
                  // Virtualization Engine Launch
                  bool isIso = isoPath.Text.EndsWith(".iso", StringComparison.OrdinalIgnoreCase);
                  string qemuArgs = "-m " + memArg + " -smp " + cpuArg + " -machine q35 -rtc base=localtime";
                  
                  if (isIso) {
                      string diskPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JemVirtual_Disk.qcow2");
                      qemuArgs += " -cdrom \"" + isoPath.Text + "\" -boot d";
                      if (!System.IO.File.Exists(diskPath)) {
                          console.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] HYPERVISOR: Creating 40GB Persistent Virtual Disk...\n");
                          string qemuImg = @"C:\Program Files\qemu\qemu-img.exe";
                          if (System.IO.File.Exists(qemuImg)) {
                              System.Diagnostics.Process.Start(new ProcessStartInfo(qemuImg, "create -f qcow2 \"" + diskPath + "\" 40G") { CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden }).WaitForExit();
                          }
                      }
                      if (System.IO.File.Exists(diskPath)) {
                          qemuArgs += " -drive file=\"" + diskPath + "\",format=qcow2,media=disk";
                      }
                  } else {
                      qemuArgs += " -drive file=\"" + isoPath.Text + "\",media=disk -boot c";
                  }

                  qemuArgs += " -vga qxl -net nic,model=virtio -net user";
                  if (accel.Checked) qemuArgs += " -accel whpx -accel tcg";
                  if (accel3D.Checked) qemuArgs += " -display default,gl=on";
                  if (usbPass.Checked) qemuArgs += " -device qemu-xhci";
"@
$content = $content.Replace($old, $new)
Set-Content -Path $path -Value $content
