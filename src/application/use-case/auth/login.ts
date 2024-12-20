import { PasswordHash } from "@/application/security/bcrypt";
import { prisma } from "@/infrastructure /prisma/prisma";
import { FastifyReply, FastifyRequest } from "fastify";

type Login = {
  email: string;
  password: string;
};

export class LoginUseCase {
  constructor(private req: FastifyRequest, private res: FastifyReply) {}

  async execute({ email, password }: Login): Promise<{ accessToken: string }> {
    const user = await prisma.user.findUnique({
      where: {
        email,
      },
    });

    if (!user) {
      throw new Error("User not found");
    }

    const passwordMatch = await PasswordHash.compare(password, user.password);

    if (!passwordMatch) {
      throw new Error("Invalid password");
    }

    const token = await this.res.jwtSign({
      id: user.id,
      email: user.email,
    });

    return {
      accessToken: token,
    };
  }
}
