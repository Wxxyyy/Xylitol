#if (net5)
Serve.Run<Xylitol.Startup>(RunOptions.Default.WithArgs(args));
#else
Serve.Run(RunOptions.Default.WithArgs(args));
#endif