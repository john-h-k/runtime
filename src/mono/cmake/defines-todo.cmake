#
# Defines no supported by the CMAKE build yet
#

#option (MAJOR_IN_MKDEV "Define to 1 if `major', `minor', and `makedev' are declared in <mkdev.h>.")
#option (MAJOR_IN_SYSMACROS "Define to 1 if `major', `minor', and `makedev' are declared in <sysmacros.h>.")
#option (STRERROR_R_CHAR_P "Define to 1 if strerror_r returns char *.")
#option (HAVE_LIBICONV "Define to 1 if you have the `iconv' library (-liconv).")
#option (ANDROID_UNIFIED_HEADERS "Whether Android NDK unified headers are used")
#option (MONO_DL_NEED_USCORE "Does dlsym require leading underscore.")
#option (GLIBC_BEFORE_2_3_4_SCHED_SETAFFINITY "Have GLIBC_BEFORE_2_3_4_SCHED_SETAFFINITY")
#option (GLIBC_HAS_CPU_COUNT "GLIBC has CPU_COUNT macro in sched.h")
#option (HAVE_LARGE_FILE_SUPPORT "Have large file support")
#option (HAVE_WORKING_SIGALTSTACK "Have a working sigaltstack")
#option (HAVE_EPOLL "epoll_create1")
#option (USE_KQUEUE_FOR_THREADPOOL "Use kqueue for the threadpool")
#option (HAVE_SIOCGIFCONF "Can get interface list")
#option (PACKAGE_NAME "Define to the full name of this package.")
#option (PACKAGE_TARNAME "Define to the one symbol short name of this package.")
#option (PACKAGE_VERSION "Define to the version of this package.")
#option (PACKAGE_STRING "Define to the full name and version of this package.")
#option (PACKAGE_BUGREPORT "Define to the address where bug reports for this package should be sent.")
#option (PACKAGE_URL "Define to the home page for this package.")
#option (HOST_NO_SYMLINKS "This platform does not support symlinks")
#option (NEED_LINK_UNLINK "Define if Unix sockets cannot be created in an anonymous namespace")
#option (HAVE_CLASSIC_WINAPI_SUPPORT "Use classic Windows API support")
#option (HAVE_UWP_WINAPI_SUPPORT "Don't use UWP Windows API support")
#option (HAVE_SYS_ZLIB "Use OS-provided zlib")
#option (MONO_XEN_OPT "Xen-specific behaviour")
#option (MONO_SMALL_CONFIG "Reduce runtime requirements (and capabilities)")
#option (AC_APPLE_UNIVERSAL_BUILD "Define if building universal (internal helper macro)")
#option (MONO_JEMALLOC_ASSERT "Make jemalloc assert for mono")
#option (MONO_JEMALLOC_DEFAULT "Make jemalloc default for mono")
#option (MONO_JEMALLOC_ENABLED "Enable jemalloc usage for mono")
#option (MONO_PRIVATE_CRASHES "Do not include names of unmanaged functions in the crash dump")
#option (DISABLE_STRUCTURED_CRASH "Do not create structured crash files during unmanaged crashes")
#option (ENABLE_MONODROID "Enable runtime support for Monodroid (Xamarin.Android)")
#option (ENABLE_MONOTOUCH "Enable runtime support for Monotouch (Xamarin.iOS and Xamarin.Mac)")
#option (DISABLED_FEATURES "String of disabled features")
#option (ENABLE_ILGEN "Some VES is available at runtime")
#option (ENABLE_EXTENSION_MODULE "Extension module enabled")
#option (DEFAULT_GC_NAME "GC description")
#option (HAVE_NULL_GC "No GC support.")
#option (MONO_ZERO_LEN_ARRAY "Length of zero length arrays")
#option (KEVENT_HAS_VOID_UDATA "kevent with void *data")
#option (BIND_ADDRLEN_UNSIGNED "bind with unsigned addrlen")
#option (IPV6MR_INTERFACE_UNSIGNED "struct ipv6_mreq with unsigned ipv6mr_interface")
#option (INOTIFY_RM_WATCH_WD_UNSIGNED "inotify_rm_watch with unsigned wd")
#option (PRIORITY_REQUIRES_INT_WHO "getpriority with int who")
#option (KEVENT_REQUIRES_INT_PARAMS "kevent with int parameters")
#option (ENABLE_GSS "ENABLE_GSS")
#option (NAME_DEV_RANDOM "Name of /dev/random")
#option (MONO_BIG_ARRAYS "Enable the allocation and indexing of arrays greater than Int32.MaxValue")
#option (ENABLE_DTRACE "Enable DTrace probes")
#option (MONO_OFFSETS_FILE "AOT cross offsets file")
#option (ENABLE_LLVM "Enable the LLVM back end")
#option (ENABLE_LLVM_MSVC_ONLY "Enable the LLVM back end")
#option (INTERNAL_LLVM "LLVM used is being build during mono build")
#option (INTERNAL_LLVM_MSVC_ONLY "LLVM used is being build during mono build")
#option (INTERNAL_LLVM_ASSERTS "Build LLVM with assertions")
#option (INTERNAL_LLVM_ASSERTS_MSVC_ONLY "Build LLVM with assertions")
#option (MONO_LLVM_LOADED "The LLVM back end is dynamically loaded")
#option (ENABLE_LLVM_RUNTIME "Runtime support code for llvm enabled")
#option (ENABLE_LLVM_RUNTIME_MSVC_ONLY "Runtime support code for llvm enabled")
#option (MONO_ARCH_ILP32 "64 bit mode with 4 byte longs and pointers")
#option (MONO_CROSS_COMPILE "The runtime is compiled for cross-compiling mode")
#option (__mono_ppc64__ "...")
#option (DISABLE_HW_TRAPS "...")
#option (HAVE_VISIBILITY_HIDDEN "Support for the visibility (hidden) attribute")
#option (ENABLE_OVERRIDABLE_ALLOCATORS "Overridable allocator support enabled")
#option (ENABLE_ICALL_SYMBOL_MAP "Icall symbol map enabled")
#option (ENABLE_ICALL_EXPORT "Icall export enabled")
#option (DISABLE_ICALL_TABLES "Icall tables disabled")
#option (MONO_KEYWORD_THREAD "Have __thread keyword")
#option (HAVE_TLS_MODEL_ATTR "tls_model available")
#option (HAVE_ARMV5 "ARM v5")
#option (HAVE_ARMV6 "ARM v6")
#option (HAVE_ARMV7 "ARM v7")
#option (RISCV_FPABI_DOUBLE "RISC-V FPABI is double-precision")
#option (RISCV_FPABI_SINGLE "RISC-V FPABI is single-precision")
#option (RISCV_FPABI_SOFT "RISC-V FPABI is soft float")
#option (USE_MALLOC_FOR_MEMPOOLS "Use malloc for each single mempool allocation")
#option (LAZY_GC_THREAD_CREATION "Enable lazy gc thread creation by the embedding host.")
#option (ENABLE_COOP_SUSPEND "Enable cooperative stop-the-world garbage collection.")
#option (ENABLE_HYBRID_SUSPEND "Enable hybrid suspend for GC stop-the-world")
#option (ENABLE_EXPERIMENTS "Enable feature experiments")
#option (ENABLE_EXPERIMENT_null "Enable experiment 'null'")
#option (ENABLE_EXPERIMENT_TIERED "Enable experiment 'Tiered Compilation'")
#option (ENABLE_CHECKED_BUILD "Enable checked build")
#option (ENABLE_CHECKED_BUILD_GC "Enable GC checked build")
#option (ENABLE_CHECKED_BUILD_METADATA "Enable metadata checked build")
#option (ENABLE_CHECKED_BUILD_THREAD "Enable thread checked build")
#option (ENABLE_CHECKED_BUILD_PRIVATE_TYPES "Enable private types checked build")
#option (ENABLE_CHECKED_BUILD_CRASH_REPORTING "Enable private types checked build")
#option (HAVE_BTLS "BoringTls is supported")
#option (ENABLE_JIT_DUMP "Enable jit dump support on Linux")
#option (DISABLE_CRASH_REPORTING)
#option (ENABLE_CXX)
#option (STATIC_ICU)
