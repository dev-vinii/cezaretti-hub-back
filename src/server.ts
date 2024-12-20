import { fastify } from "fastify";
import { fastifyCors } from "@fastify/cors";
import jwt from "@fastify/jwt";

const server = fastify();

server.register(fastifyCors, {
  origin: "*",
});

server.register(jwt, {
  secret: "process.env.JWT_SECRET",
});

server.addHook("onRequest", async (request, reply) => {
  try {
    await request.jwtVerify();
  } catch (err) {
    reply.send(err);
  }
});

server.listen({ port: 3000 }).then(() => {
  console.log("Server is running on port 3000");
});
