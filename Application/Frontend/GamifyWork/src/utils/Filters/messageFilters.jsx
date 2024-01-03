export function filterMessagesByUsers(messages, senderId, receiverId) {
  return messages.filter(
    (m) =>
      (m.userSender === senderId && m.userReceiver === receiverId) ||
      (m.userSender === receiverId && m.userReceiver === senderId)
  );
}
