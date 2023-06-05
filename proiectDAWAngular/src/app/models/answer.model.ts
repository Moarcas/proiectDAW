import { SessionUser } from "./session-user.model";

export interface AnswerType {
  id: string;
  content: string;
  questionId: string;
  user: SessionUser;
  createdAt: Date;
}
