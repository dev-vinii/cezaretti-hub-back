import { fastify } from "fastify";
import { fastifyCors } from "@fastify/cors";

const server = fastify();

server.register(fastifyCors, {
  origin: "*",
});

server.listen({ port: 3000 }).then(() => {
  console.log("Server is running on port 3000");
});
