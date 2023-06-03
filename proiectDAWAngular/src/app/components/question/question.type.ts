import { SessionUser } from "app/models/session-user.model";

export interface QuestionType {
  id: string;
  userId: string;
  title: string;
  content: string;
  createdAt: Date;
  user: SessionUser;
}
