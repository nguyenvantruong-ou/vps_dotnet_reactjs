# Build stage
FROM node:18 AS builder
WORKDIR /app

# Copy package.json and package-lock.json, install dependencies
COPY package*.json ./
RUN npm install

# Copy all files
COPY . .

# Build the React app
RUN npm run build

# Kiểm tra xem thư mục dist có được tạo ra không
RUN echo "Contents of /app/dist:" && ls -la /app/dist

# Production stage (nginx)
FROM nginx:stable-alpine

# Copy the build output to the nginx html directory
COPY --from=builder /app/dist /usr/share/nginx/html

# Expose port 80 (nginx default port)
EXPOSE 80

# Command to run nginx
CMD ["nginx", "-g", "daemon off;"]
