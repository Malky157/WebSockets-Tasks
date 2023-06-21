// vite.config.js
import { defineConfig } from "file:///C:/Users/Malky/source/repos/Homework6.19/Homework6.19.Web/ClientApp/node_modules/vite/dist/node/index.js";
import react from "file:///C:/Users/Malky/source/repos/Homework6.19/Homework6.19.Web/ClientApp/node_modules/@vitejs/plugin-react/dist/index.mjs";
var vite_config_default = defineConfig({
  plugins: [react()],
  server: {
    port: 3e3,
    strictPort: true,
    proxy: {
      "/api": {
        target: "https://localhost:7066",
        changeOrigin: true,
        secure: false,
        ws: true,
        rewrite: (path) => path.replace(/^\/api/, "/api")
      }
    }
  }
});
export {
  vite_config_default as default
};
//# sourceMappingURL=data:application/json;base64,ewogICJ2ZXJzaW9uIjogMywKICAic291cmNlcyI6IFsidml0ZS5jb25maWcuanMiXSwKICAic291cmNlc0NvbnRlbnQiOiBbImNvbnN0IF9fdml0ZV9pbmplY3RlZF9vcmlnaW5hbF9kaXJuYW1lID0gXCJDOlxcXFxVc2Vyc1xcXFxNYWxreVxcXFxzb3VyY2VcXFxccmVwb3NcXFxcSG9tZXdvcms2LjE5XFxcXEhvbWV3b3JrNi4xOS5XZWJcXFxcQ2xpZW50QXBwXCI7Y29uc3QgX192aXRlX2luamVjdGVkX29yaWdpbmFsX2ZpbGVuYW1lID0gXCJDOlxcXFxVc2Vyc1xcXFxNYWxreVxcXFxzb3VyY2VcXFxccmVwb3NcXFxcSG9tZXdvcms2LjE5XFxcXEhvbWV3b3JrNi4xOS5XZWJcXFxcQ2xpZW50QXBwXFxcXHZpdGUuY29uZmlnLmpzXCI7Y29uc3QgX192aXRlX2luamVjdGVkX29yaWdpbmFsX2ltcG9ydF9tZXRhX3VybCA9IFwiZmlsZTovLy9DOi9Vc2Vycy9NYWxreS9zb3VyY2UvcmVwb3MvSG9tZXdvcms2LjE5L0hvbWV3b3JrNi4xOS5XZWIvQ2xpZW50QXBwL3ZpdGUuY29uZmlnLmpzXCI7aW1wb3J0IHsgZGVmaW5lQ29uZmlnIH0gZnJvbSAndml0ZSdcclxuaW1wb3J0IHJlYWN0IGZyb20gJ0B2aXRlanMvcGx1Z2luLXJlYWN0JztcclxuXHJcbmV4cG9ydCBkZWZhdWx0IGRlZmluZUNvbmZpZyh7XHJcbiAgcGx1Z2luczogW3JlYWN0KCldLFxyXG4gIHNlcnZlcjoge1xyXG4gICAgcG9ydDogMzAwMCxcclxuICAgIHN0cmljdFBvcnQgOiB0cnVlLFxyXG4gICAgcHJveHk6IHtcclxuICAgICAgJy9hcGknIDoge1xyXG4gICAgICAgIHRhcmdldDogJ2h0dHBzOi8vbG9jYWxob3N0OjcwNjYnLFxyXG4gICAgICAgIGNoYW5nZU9yaWdpbjogdHJ1ZSxcclxuICAgICAgICBzZWN1cmU6IGZhbHNlLFxyXG4gICAgICAgIHdzOiB0cnVlLFxyXG4gICAgICAgIHJld3JpdGU6IChwYXRoKSA9PiBwYXRoLnJlcGxhY2UoL15cXC9hcGkvLCAnL2FwaScpXHJcbiAgICAgIH1cclxuICAgIH1cclxuICB9XHJcbn0pXHJcbiJdLAogICJtYXBwaW5ncyI6ICI7QUFBMlksU0FBUyxvQkFBb0I7QUFDeGEsT0FBTyxXQUFXO0FBRWxCLElBQU8sc0JBQVEsYUFBYTtBQUFBLEVBQzFCLFNBQVMsQ0FBQyxNQUFNLENBQUM7QUFBQSxFQUNqQixRQUFRO0FBQUEsSUFDTixNQUFNO0FBQUEsSUFDTixZQUFhO0FBQUEsSUFDYixPQUFPO0FBQUEsTUFDTCxRQUFTO0FBQUEsUUFDUCxRQUFRO0FBQUEsUUFDUixjQUFjO0FBQUEsUUFDZCxRQUFRO0FBQUEsUUFDUixJQUFJO0FBQUEsUUFDSixTQUFTLENBQUMsU0FBUyxLQUFLLFFBQVEsVUFBVSxNQUFNO0FBQUEsTUFDbEQ7QUFBQSxJQUNGO0FBQUEsRUFDRjtBQUNGLENBQUM7IiwKICAibmFtZXMiOiBbXQp9Cg==
