import { SessionUser } from "app/models/session-user.model";

export interface AnswerType {
  id: string;
  userId: string;
  questionId: string;
  content: string;
  createdAt: Date;
  user: SessionUser;
}
